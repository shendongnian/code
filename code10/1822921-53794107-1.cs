                if (numbarcode < NBbarcode_perLine)
                    startX += 150;
                else
                {
                    //MessageBox.Show(rectangleHeight.ToString());
                    startX = 5;
                    startY += 200; // ***** space between 2 lines increased
                    numbarcode = 0;
                }
