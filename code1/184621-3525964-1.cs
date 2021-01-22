        protected void GenerateNestedStringSearch<T>(ILGenerator gen, T[] values, Func<T, string> getName, Action<ILGenerator, T> loadValue)
        {
            //We'll jump here if no match found
            Label notFound = gen.DefineLabel();
            //Try to match the string
            GenerateNestedStringSearch(gen, notFound, values, getName, loadValue, 0);
            //Nothing found, so don't need string anymore
            gen.MarkLabel(notFound);
            gen.Emit(OpCodes.Pop);
            //Throw ArgumentOutOfRangeException to indicate not found
            gen.EmitLdc("name");
            gen.EmitLdc("Binding does not contain a tag with the specified name: ");
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Call, typeof(String).GetMethod("Concat",
                                                            BindingFlags.Static | BindingFlags.Public,
                                                            null,
                                                            new[] { typeof(string), typeof(string) },
                                                            null));
            gen.Emit(OpCodes.Newobj,
                     typeof(ArgumentOutOfRangeException).GetConstructor(new[] { typeof(string), typeof(string) }));
            gen.Emit(OpCodes.Throw);
        }
        protected void GenerateNestedStringSearch<T>(ILGenerator gen, Label notFound, T[] values, Func<T, string> getName, Action<ILGenerator, T> loadValue, int charIndex)
        {
            //Load the character from the candidate string for comparison
            gen.Emit(OpCodes.Dup);
            gen.EmitLdc(charIndex);
            gen.Emit(OpCodes.Ldelem_U2);
            //Group possible strings by their character at this index
            //We ignore strings that are too short
            var strings = values.Select(getName).ToArray();
            var stringsByChar =
                from x in strings
                where charIndex < x.Length
                group x by x[charIndex]
                    into g
                    select new { FirstChar = g.Key, Strings = g };
            foreach (var grouped in stringsByChar)
            {
                //Compare source character to group character and jump ahead if it doesn't match
                Label charNotMatch = gen.DefineLabel();
                gen.Emit(OpCodes.Dup);
                gen.EmitLdc(grouped.FirstChar);
                gen.Emit(OpCodes.Bne_Un, charNotMatch);
                //If there is only one string in this group, we've found our match
                int count = grouped.Strings.Count();
                Debug.Assert(count > 0);
                if (count == 1)
                {
                    //Don't need the source character or string anymore
                    gen.Emit(OpCodes.Pop);
                    gen.Emit(OpCodes.Pop);
                    //Return the value for this name
                    int index = Array.FindIndex(strings, s => s == grouped.Strings.First());
                    loadValue(gen, values[index]);
                    gen.Emit(OpCodes.Ret);
                }
                else
                {
                    //Don't need character anymore
                    gen.Emit(OpCodes.Pop);
                    //If there is a string that ends at this character
                    string endString = grouped.Strings.FirstOrDefault(s => s.Length == (charIndex + 1));
                    if (endString != null)
                    {
                        //Get string length
                        gen.Emit(OpCodes.Dup);
                        gen.Emit(OpCodes.Call, typeof(char[]).GetProperty("Length").GetGetMethod());
                        //If string length matches ending string
                        gen.EmitLdc(endString.Length);
                        Label keepSearching = gen.DefineLabel();
                        gen.Emit(OpCodes.Bne_Un, keepSearching);
                        //Don't need the source string anymore
                        gen.Emit(OpCodes.Pop);
                        //Create an UnboundTag for this index
                        int index = Array.FindIndex(strings, s => s == endString);
                        loadValue(gen, values[index]);
                        gen.Emit(OpCodes.Ret);
                        //String length didn't match
                        gen.MarkLabel(keepSearching);
                    }
                    //Need to consider strings starting with next character
                    var nextValues = from s in grouped.Strings
                                     join v in values on s equals getName(v) 
                                     select v;
                    GenerateNestedStringSearch(gen, notFound, nextValues.ToArray(),
                        getName, loadValue, charIndex + 1);
                }
                //This character didn't match, so consider next character
                gen.MarkLabel(charNotMatch);
            }
            //We don't need the character anymore
            gen.Emit(OpCodes.Pop);
            //No string match, so jump to Not Found at end of check
            gen.Emit(OpCodes.Br, notFound);
        }
