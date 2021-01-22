        [Test]
        // [Ignore]
        public void TestRedirect()
        {
            Redirector.Redirect();
            // Call more functions that output to std::cerr here.
            Redirector.Revert();
            System.Console.WriteLine(Redirector.GetCerr());
        }
