        //Why are you creating lists??? Why not just use the arrays which are passed
        //To your method???
        //You shouldn't be trying to declare local variables with
        //the same names as the parameters being passed to the method
        public (string[] workareaRefs, string[] jurisdictions, string[] tags) FiltersQS(NameValueCollection parameters)
        
        //Commented these out, not necessary
        //var workAreaRefs = new List<string>();
        //var jurisdictions = new List<string>();
        //var tags = new List<string>();
        
        //Change your if statements
        //if (WorkAreas.Count == 0 && workAreaRefs.Count == 0) //NO
        if(workareaRefs.Length > 0) //Yes
        {
            foreach (var workAreaRef in parameters["workarearef"])
            {
                workAreaRefs.Add(workAreaRef);
            }
        }
        //etc. Other ifs need modified like above
