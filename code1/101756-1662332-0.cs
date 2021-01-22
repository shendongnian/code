    double amp = 1.3;   // Set your amplitide here
            double T = 4; // set the period here
            PointPairList ppl = new PointPairList();
            
            for(int i=0; i<10; i++) // 10 = number of periods shown
            {
                ppl.Add(i*T, 0);
                ppl.Add(i*T + 0.25*T, amp);
                ppl.Add(i*T + 0.5*T, 0);
                ppl.Add(i*T + 0.75*T, -amp);
            }
            ppl.Add(10*T, 0); // add the last element to end at zero-line
            var line = zg1.MasterPane[0].AddCurve("", ppl, Color.Blue);
            line.Symbol.IsVisible = false;
