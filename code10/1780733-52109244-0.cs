    foreach (var item in firstOuterList)
            {
                var secondItem = secondOuterList.Find(so => so.Id == item.Id);
                //if secondItem is null->throw exception
                if (item.Name == secondItem.Name)
                {
                    foreach (var firstInnerItem in item.Inners)
                    {
                        var secondInnerItem = secondItem.Inners.Find(sI => sI.Id == firstInnerItem.Id);
                        //if secondInnerItem is null,throw exception
                        if (firstInnerItem.Type != secondInnerItem.Type)
                        {
                            //throw exception
                        }
                    }
                }
                else
                {
                    //throw exception
                }
            }
            //move with normal flow
