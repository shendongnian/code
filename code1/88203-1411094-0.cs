            sw.Start();
            for (int i = 0; i < loopCount; i++)
            {
                x = point._x;
                y = point._y;
                z = point._z;
                calculatedValue = x * y / z;
            }
            sw.Stop();
            double fieldTime = sw.ElapsedMilliseconds;
            Console.WriteLine("Direct field access: " + fieldTime);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < loopCount; i++)
            {
                x = point.X;
                y = point.Y;
                z = point.Z;
                calculatedValue = x * y / z;
            }
            sw.Stop();
