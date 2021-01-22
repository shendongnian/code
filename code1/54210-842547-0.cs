                // Peek at the next line
                long peekPos = reader.BaseStream.Position;
                string line = reader.ReadLine();
                if (line.StartsWith("<tag start>"))
                {
                    // This is a new tag, so we reset the position
                    reader.BaseStream.Seek(pos);    
    
                }
                else
                {
                    // This is part of the same node.
                }
