            list.AddLast(new Temp(1,1,1,1));
            var referenceNode = list.First;
            for (var i = 0; i < 123456; i++)
            {
                var a = new Temp(i, i, i, i);
                list.AddLast(a);
                list.AddBefore(referenceNode, a);
            }
            decimal sum = 0;
            foreach (var item in list)
                sum += item.A;
