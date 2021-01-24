    using System; // Other usings 
    using NUnit.Framework;
    namespace MyTests
    {
    ....
    [TestCase("irm_xxx_tbbmf_xu.csv.ovr", "6677,6677_6677,3001,6")]
    [TestCase("irm_xxx_tbbmf_xxx.csv.ovr", "6677,22,344")]
    public void ValidateInventoryMeasurement(string path, string expected)
    {
        const string processFilePath = "/orabin/product/inputs/actuals/";
        var actual = Common.LinuxCommandExecutor
                           .RunLinuxcommand($"cat {processFilePath}{path}");
        Assert.AreEqual(expected, actual);
    }
