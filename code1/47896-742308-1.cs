    $source = @"
    public class BasicTest
    {
        public static int Add(int a, int b)
        {
            return (a + b);
        }
    
        public int Multiply(int a, int b)
        {
            return (a * b);
        }
    }
    "@
    
    Add-Type -TypeDefinition $source
    [BasicTest]::Add(4, 3)
    $basicTestObject = New-Object BasicTest 
    $basicTestObject.Multiply(5, 2)
