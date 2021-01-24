    // polygon vertex
                Actions vertex1 = new Actions(driver);
                vertex1.MoveToElement(map).MoveByOffset(100, 100).Click();
                IAction clickNextPoint = vertex1.Build();
                clickNextPoint.Perform();
    
                Actions vertex2 = new Actions(driver);
                vertex2.MoveToElement(map).MoveByOffset(10,100).Click();
                IAction clickNextPoint2 = vertex2.Build();
                clickNextPoint2.Perform();
    
                Actions vertex3 = new Actions(driver);
                vertex3.MoveToElement(map).MoveByOffset(10, 10).Click();
                IAction clickNextPoint3 = vertex3.Build();
                clickNextPoint3.Perform();
    
                Actions vertex4 = new Actions(driver);
                vertex4.MoveToElement(karte).MoveByOffset(100, 10).DoubleClick();
                System.Threading.Thread.Sleep(3000);
