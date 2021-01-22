            Action x = new Action(() =>
            {
                var xx = "i am a string";
            });
            Action x1 = new Action(() =>
            {
            });
            MethodBody mb = x.Method.GetMethodBody();
            MethodBody mb1 = x1.Method.GetMethodBody();
            byte[] b = mb.GetILAsByteArray();
            byte[] b1 = mb1.GetILAsByteArray();
