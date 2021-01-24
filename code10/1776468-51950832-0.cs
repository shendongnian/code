    //decides if to put cell alive or dead
                        if (neighborAliveCounter < 2 || neighborAliveCounter > 3)
                        {
                            tempCollection.Add(new CellModel() { Row = CellCollection[i].Row, Column = CellCollection[i].Column, CellBackgroundColor = new SolidColorBrush(Colors.Transparent), IsAlive = false });
                        }
    
                        if (neighborAliveCounter == 3)
                        {                        
    tempCollection.Add(new CellModel() { Row = CellCollection[i].Row, Column = CellCollection[i].Column, CellBackgroundColor = new SolidColorBrush(Colors.LightSeaGreen), IsAlive = true });
                        }
