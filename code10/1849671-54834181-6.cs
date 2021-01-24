csharp
var t1 = Task.Run(async () => { var x = await T1(); UseV1(x); return x; });
var t2 = Task.Run(async () => { var x = await T2(); UseV2(x); return x; });
var t3 = Task.Run(async () => { var x = await T3(); UseV3(x); return x; });
var t4 = Task.Run(async () => { var x = await T4(); UseV4(x); return x; });
await Task.WhenAll(t1, t2, t3, t4);
UseAll(t1.Result, t2.Result, t3.Result, t4.Result);
**Using `ContinueWith`**
csharp
var t1 = T1().ContinueWith(x => { UseV1(x.Result); return x.Result; });
var t2 = T2().ContinueWith(x => { UseV2(x.Result); return x.Result; });
var t3 = T3().ContinueWith(x => { UseV3(x.Result); return x.Result; });
var t4 = T4().ContinueWith(x => { UseV4(x.Result); return x.Result; });
await Task.WhenAll(t1, t2, t3, t4);
UseAll(t1.Result, t2.Result, t3.Result, t4.Result);
