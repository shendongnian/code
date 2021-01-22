        TextPointer FindWordsFromPosition(TextPointer position, IList<string> words)
        {
            var firstPosition = position;
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) ==    TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);
                    var indexesInRun = new List<int>();
                    foreach (var word in words)
                    {
                        var index = textRun.IndexOf(word);
                        if (index == 0)
                            index = textRun.IndexOf(word, 1);
                        indexesInRun.Add(index);
                    }
                    indexesInRun = indexesInRun.Where(i => i != 0 && i != -1).OrderBy(i => i).ToList();
                    if (indexesInRun.Any())
                    {
                        position = position.GetPositionAtOffset(indexesInRun.First());
                        break;
                    }
                    
                    return firstPosition;
                }
                else
                    position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
            return position;
        }
