            Parallel.ForEach(range, i =>
            {
                AppDomain otherDomain = AppDomain.CreateDomain(i.ToString());
                var comCall = (ComCall) otherDomain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(ComCall).ToString());
                comCall.Run();
                AppDomain.Unload(otherDomain);
            });
