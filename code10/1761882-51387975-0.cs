     int i;
            for(int x = 0; x < rows; x++) //row
            {
                string buttonbyte = "{";
                for (i = x; i < columns + x; i++) //column
                {
                    buttonbyte += (i + columns*x); // collum + collumns* row
                    buttonbyte += ",";
                }
                sketch[9 + x] = buttonbyte + "},";
                
            }
