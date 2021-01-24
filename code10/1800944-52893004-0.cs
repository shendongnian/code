        public List<Output> Flatten(Input input)
        {
            var outputs = new List<Output>();
            foreach (var aKey in input.A.Keys)
            {
                //Check that input.B really has the key found in input.A
                outputs.Add(new Output{Key = aKey, A = input.A[aKey], B = input.B.ContainsKey(aKey)? input.B[aKey]:null});
            }
            //If input.B has some keys not in input.A 
            foreach (var bKey in input.B.Keys)
            {
                //Check that the bKey was not already inserted (didn't exist earlier)
                if (outputs.All(x => x.Key != bKey))
                {
                    //A can be null.. it was not in the input.A
                    outputs.Add(new Output {Key = bKey, A = null, B = input.B[bKey]});
                }
            }
            return outputs;
        }
