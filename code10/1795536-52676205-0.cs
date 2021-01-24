            var array = new int[][]
            {
                new int[]{1},
                new int[]{2,3}
            };
            // change existing element
            array[1][0]=0;
            // add row & fill it
            Array.Resize(ref array, 3);
            Array.Resize(ref array[2], 1);
            array[2][0]=5;
            // resize existing row
            Array.Resize(ref array[1], 3);
            array[1][2]=6;
