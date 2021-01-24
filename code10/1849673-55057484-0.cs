    async Task<int> T1() { return await Task.FromResult(1); }
    async Task<string> T2() { return await Task.FromResult("T2"); }
    async Task<char> T3() { await Task.Delay(2000); return await Task.FromResult('A'); }
    async Task<string> T4() { return await Task.FromResult("T4"); }
    var t1 = T1().ContinueWith(x => { Console.WriteLine($"Use T1: {x.Result}"); return x.Result; });
    var t2 = T2().ContinueWith(x => { Console.WriteLine($"Use T2: {x.Result}"); return x.Result; });
    var t3 = T3().ContinueWith(x => { Console.WriteLine($"Use T3: {x.Result}"); return x.Result; });
    var t4 = T4().ContinueWith(x => { Console.WriteLine($"Use T4: {x.Result}"); return x.Result; });
    await Task.WhenAll(t1, t2, t3, t4);
    Console.WriteLine("Done");
