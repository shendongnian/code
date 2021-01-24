        private void Load_button_Click(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load("test.xml");
            //First of all, we want to isolate xml data parsing and result composition. We will store our names in a list.
            List<string> names = new List<string>();
            //Get all tag elements (Layers, Variables)
            foreach (var tag in xDoc.Root.Elements())
            {
                //Get all entries for the tag
                foreach (var entry in tag.Elements())
                    //For each entry, we want to get the text of the first child (LayerName, VariableName etc) and add it to our list
                    names.Add(entry.Elements().First().Value);
            }
            //Use String.Join to compose collection elements into desired result
            results_textbox.Text = String.Join(",", names);
        }
