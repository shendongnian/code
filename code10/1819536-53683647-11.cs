    class Program
    {
        static string CalculateKernel
        {
            get
            {
                return @"
                kernel void Calc(global int* m1, global int* m2, int size) 
                {
                    for(int i = 0; i < size; i++)
                    {
                        printf("" %d / %d\n"",m1[i],m2[i] );
                    }
                }";
            }
        }
    static void Main(string[] args)
        {
            int[] r1 = new int[]
                {1, 2, 3, 4};
            int[] r2 = new int[]
                {4, 3, 2, 1};
            int rowSize = r1.Length;
            // pick first platform
            ComputePlatform platform = ComputePlatform.Platforms[0];
            // create context with all gpu devices
            ComputeContext context = new ComputeContext(ComputeDeviceTypes.Gpu,
                new ComputeContextPropertyList(platform), null, IntPtr.Zero);
            // create a command queue with first gpu found
            ComputeCommandQueue queue = new ComputeCommandQueue(context,
                context.Devices[0], ComputeCommandQueueFlags.None);
            // load opencl source and
            // create program with opencl source
            ComputeProgram program = new ComputeProgram(context, CalculateKernel);
            // compile opencl source
            program.Build(null, null, null, IntPtr.Zero);
            // load chosen kernel from program
            ComputeKernel kernel = program.CreateKernel("Calc");
            // allocate a memory buffer with the message (the int array)
            ComputeBuffer<int> row1Buffer = new ComputeBuffer<int>(context,
                ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, r1);
            // allocate a memory buffer with the message (the int array)
            ComputeBuffer<int> row2Buffer = new ComputeBuffer<int>(context,
                ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, r2);
            kernel.SetMemoryArgument(0, row1Buffer); // set the integer array
            kernel.SetMemoryArgument(1, row2Buffer); // set the integer array
            kernel.SetValueArgument(2, rowSize); // set the array size
                // execute kernel
            queue.ExecuteTask(kernel, null);
            // wait for completion
            queue.Finish();
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
