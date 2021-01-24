                List<double> X = new List<double> { 10, 12, 18, 30 };  // assume to be LogNormal
                double m = X.Mean();               // mean of log normal values = 17.5
                double sd = X.StandardDeviation(); // standard deviation of log normal values = 9
    
                List<double> Y = new List<double> { };
                for (int i = 0; i < 4; i++)
                {
                    Y.Add(Math.Log(X[i]));
                }
                // Y = {2.30,2.48,2.89,3.4}
    
                double mu = Y.Mean();                 // mean of normal values = 2.77
                double sigma = Y.StandardDeviation(); // standard deviation of normal values = 0.487
    
                double[] sample = new double[100];
                LogNormal.Samples(sample, mu, sigma);          // get sample    
                double sample_m = sample.Mean();               // 17.93, approximates m
                double sample_sd = sample.StandardDeviation(); // 8.98, approximates sd
    
                sample = new double[100];
                Normal.Samples(sample, mu, sigma);                // get sample    
                double sample_mu = sample.Mean();                 //2.77, approximates mu
                double sample_sigma = sample.StandardDeviation(); //0.517 approximates sigma
