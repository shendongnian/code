            [Benchmark(Baseline = true)]
            public void MatrixTest()
            {
                float[,,] saveArray = new float[501, 501, 361];
    
                for (int x = 0; x <= 500; x++)
                    for (int y = 0; y <= 500; y++)
                        for (int angle = 0; angle <= 360; angle++)
                            if (saveArray[x, y, angle] == 0) saveArray[x, y, angle] = 42;
            }
            
            [Benchmark]
            void IntKeyDictionaryTest()
            {
                Dictionary<int, float> saveDictionary = new Dictionary<int, float>();
    
                for (int x = 0; x <= 500; x++)
                    for (int y = 0; y <= 500; y++)
                        for (int angle = 0; angle <= 360; angle++)
                        {
                            int key = (x << 18) | (y << 9) | (angle);
                            if (!saveDictionary.TryGetValue(key, out float d)) saveDictionary[key] = 42;
                        }
            }
            [Benchmark]
            void DoubleKeyDictionaryTest()
            {
                Dictionary<double, float> saveDictionary = new Dictionary<double, float>();
    
                for (int x = 0; x <= 500; x++)
                    for (int y = 0; y <= 500; y++)
                        for (int angle = 0; angle <= 360; angle++)
                        {
                            double key = (double)x * 1000 + (double)y + (double)angle / 1000l;
                            if (!saveDictionary.TryGetValue(key, out float d)) saveDictionary[key] = 42;
                        }
            }
