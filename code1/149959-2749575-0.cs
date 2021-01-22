    class Program
    {
        private static float[] vector1, vector2;
        private static CUDA cuda;
        private static CUBLAS cublas;
        private static CUdeviceptr ptr;
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static void Main()
        {
            cuda = new CUDA(true);
            cublas = new CUBLAS(cuda);
            //allocate vector on cuda device in main thread
            CudaManager.CallMethod(AllocateVectors);
            //changing first vector from other thread
            Thread changeThread = new Thread(ChangeVectorOnDevice_ThreadRun) { IsBackground = false };
            changeThread.Start();
            //wait for changeThread to finish
            autoResetEvent.WaitOne();
            //getting vector from device in another one thread
            Thread getThread = new Thread(GetVectorFromDevice_ThreadRun) { IsBackground = false };
            getThread.Start();
            //wait for getThread to finish
            autoResetEvent.WaitOne();
            Console.WriteLine("({0}, {1}, {2}, {3}, {4})", vector2[0], vector2[1], vector2[2], vector2[3], vector2[4]);
            Console.ReadKey(true);
        }
        private static void AllocateVectors()
        {
            vector1 = new[] { 1f, 2f, 3f, 4f, 5f };
            vector2 = new float[5];
            //allocate memory and copy first vector to device
            ptr = cublas.Allocate(vector1.Length, sizeof(float));
            cublas.SetVector(vector1, ptr);
        }
        private static void GetVectorFromDevice()
        {
            cublas.GetVector(ptr, vector2);
        }
        private static void ChangeVectorOnDevice()
        {
            //changing vector and copying it to device
            vector1 = new[] { -1f, -2f, -3f, -4f, -5f };
            cublas.SetVector(vector1, ptr);
        }
        private static void ChangeVectorOnDevice_ThreadRun()
        {
            CudaManager.CallMethod(ChangeVectorOnDevice);
            //releasing main thread
            autoResetEvent.Set();
        }
        private static void GetVectorFromDevice_ThreadRun()
        {
            CudaManager.CallMethod(GetVectorFromDevice);
            //releasing main thread
            autoResetEvent.Set();
        }
    }
    public static class CudaManager
    {
        public static Action WorkMethod { get; private set; }
        private static readonly AutoResetEvent actionRecived = new AutoResetEvent(false);
        private static readonly AutoResetEvent callbackEvent = new AutoResetEvent(false);
        private static readonly object mutext = new object();
        private static bool isCudaThreadRunning;
        private static void ThreadRun()
        {
            //waiting for work method to execute
            while (actionRecived.WaitOne())
            {
                //invoking recived method
                WorkMethod.Invoke();
                //releasing caller thread
                callbackEvent.Set();
            }
        }
        static CudaManager()
        {
            Run();
        }
        public static void Run()
        {
            if (!isCudaThreadRunning)
            {
                Thread thread = new Thread(ThreadRun);
                thread.IsBackground = true;
                thread.Start();
                isCudaThreadRunning = true;
            }
        }
        public static void CallMethod(Action method)
        {
            lock (mutext)
            {
                WorkMethod = method;
                //releasing ThreadRun method
                actionRecived.Set();
                //blocking caller thread untill delegate invokation is complete
                callbackEvent.WaitOne();
            }
        }
    }
