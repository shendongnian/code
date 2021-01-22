      double x = 1.1, y = 5.1, a = 6.1, b = 7.1, p = 8.1, q = 9.1, c = 10.1, d = 15.1;
      double S, C, A, Ad;
      for (S=x; S <= y; S = S + .5)
        for (C=a; C <= b; C = C + .25)
          for (A=p; A <= q; A = A + 1.0)
            for (Ad=c; Ad <= d; Ad = Ad + 1.5)
              Console.WriteLine("S={0} C={1} A={2}, Ad={3}", S, C, A, Ad);
      Console.ReadLine();
