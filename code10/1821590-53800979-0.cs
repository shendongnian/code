        private void ValidateB_Click(object sender, RoutedEventArgs e)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                string txt = proInp.Text;
                var eng = Python.CreateEngine();
                var searchPaths = eng.GetSearchPaths();
                searchPaths.Add("F:\\Python27\\Lib");
                searchPaths.Add("F:\\Python 3.6\\Lib");
                eng.SetSearchPaths(searchPaths);
                var scope = eng.CreateScope();
                scope.SetVariable("key", txt);
                eng.Execute("import os\nkey="os.getcwd()", scope);
            });
        }
