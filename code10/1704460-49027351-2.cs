                if (_parents.Count == 0)
                {
                    Console.WriteLine("There is no parent for ID: " + _id);
                    return;
                }
                int _featureId = 0, _userstoryId = 0;
                string _featureTitle = "", _userstoryTitle = "";
                for (int i = 0; i < _parents.Count; i++)
                    switch (_parents[i].Type.Name)
                    {
                        case "Feature":
                            if (_featureId == 0) { _featureId = _parents[i].Id; _featureTitle = _parents[i].Title; }
                            break;
                        case "Product Backlog Item": //for scrum process template. for agile use User Story
                            if (_userstoryId == 0) { _userstoryId = _parents[i].Id; _userstoryTitle = _parents[i].Title; }
                            break;
                    }
                if (_featureId != 0) Console.WriteLine("The main parent is Feature: {0}: '{1}'", _featureId, _featureTitle);
                else if (_userstoryId != 0) Console.WriteLine("The main parent is User Story: {0}: '{1}'", _userstoryId, _userstoryTitle);
