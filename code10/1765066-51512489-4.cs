    public void readCSV(string filename, MainWindow mw)
    {
        var result = File.ReadAllLines(filename)
                    .Select(line => line.Split(';'))
                    .Select(x => new MyObject { 
                        prop1 = x[0],
                        prop2 = x[1],
                        //etc.. 
                    })
        return result;
    }
