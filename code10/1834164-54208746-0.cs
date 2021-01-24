using System;
using System.Text.RegularExpressions;
namespace Programming {
    class Program {
        static void Main() {
            string content = "namespace MyNameSpace1\n{\n    [TestClass]\n    public class GetMapPathActionTests\n    {\n        [TestMethod] // 1\n        public void GetMapPath_with_All_Attibutes()\n        {\n            ...\n        }\n        [TestMethod] // 2\n        [ExpectedException(typeof(DBInstallInfoConverterCrossCheckerRequiredChildNotFoundException))]\n        public void GetMapPath_with_Empty_Input()\n        {\n           \n        }\n        [TestMethod] // 3\n        [ExpectedException(typeof(DBInstallInfoConverterCrossCheckerRequiredChildNotFoundException))]\n        public void GetMapPath_with_Empty_Output()\n        {\n            \n        }\n        [TestMethod] // 4\n        public void GetMapPath_with_Empty()\n        {\n            \n        }\n        [TestMethod] // 5\n        [ExpectedException(typeof(DBInstallInfoConverterCrossCheckerRequiredChildNotFoundException))]\n        public void GetMapPath_with_All_Attibutes_Empty()\n        {\n            \n        }\n    }\n}\n";
            Regex regex = new Regex(@"^[\t ]*\[TestMethod\][ \t\w\/äÄüÜöÖß]*(\s+\[(?!TestCategory\(TestCategories\.GatedCheckin\)).+\][ \t\w\/äÄüÜöÖß]*)?\s+public", RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(content);
            foreach (Match match in matches) {
                foreach (Capture capture in match.Captures) {
                    Console.WriteLine(capture.Value);
                }
            }
        }
    }
}
