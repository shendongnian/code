    private void ExtractValuesFromAppconstants(string keyName)
            {
                Type type = typeof(YourClass);
                var examination = type.GetNestedType(keyName);
                if (examination != null)
                {    
                    var innerTypes = examination.GetNestedTypes();
                    foreach (var innerType in innerTypes)
                    {
                        Console.Writeline($"{innerType.Name}")
                    }
                }
            }
