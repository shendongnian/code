            XmlNodeList nodeList = docs.SelectNodes(query)
            XmlNode node;
            for (int i = 0; i < nodeList.Count; i++)
            {
                node = nodeList[i];
                if (condition == true)
                {
                    int itemsToSkip = 0;
                    string nextnodetest;
                    do
                    {
                       ...
                        if (nextnodetest == "Programme")
                        {
                            itemsToSkip++;
                            //calculate duration.
                        }
                    } while (nextnodetest != "Programme");
                    i = i + itemsToSkip;
                }
                ... your code 
            }
