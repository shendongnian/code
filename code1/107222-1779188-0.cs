        extern "C" __declspec(dllexport) int DoProcessing(int);
    Next you import the function in managed code:
        class Program 
        {
            [DllImport("mylibrary.dll")]
            static extern int DoProcessing(int input);
            static void Main()
            {
                int result = DoProcessing(123);
            }
        }
    This works if the input and output of your processing is not very complex and can be easily marshaled. It will have very little overhead.
