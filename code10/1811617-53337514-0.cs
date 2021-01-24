                List<A> myList = getYourListForWhereEver();
                var filteredList = new List<A>();
                foreach (var item in myList)
                {
                    var existing = filteredList.FirstOrDefault(x => x.familyId == item.familyId);
                    if (existing == null)
                    {
                        // family is unique so add it
                        filteredList.Add(item);
                    }
                    else
                    {
                        // check the score and replace if score is lower
                        if (existing.Score < item.Score)
                        {
                            filteredList.Remove(existing);
                            filteredList.Add(item);
                        }
                    }
                }
