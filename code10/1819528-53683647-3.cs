    class Program
    {
        static string CalculateKernel
        {
            get
            {
                return @"
                kernel void Calc(global int* m1, global int* m2, int size, global int* m3) 
                {
                    for(int i = 0; i < size; i++)
                    {
                        int val = m2[i];
                        printf("" %d / %d\n"",m1[i],m2[i] );
                        m3[i] = val * 4;
                    }
                }";
            }
        }
    static void Main(string[] args)
        {
            int[] r1 = new int[]
                {8, 2, 3, 4};
            int[] r2 = new int[]
                {4, 3, 2, 5};
            int[] r3 = new int[4];
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
            // allocate a memory buffer with the message (the int array)
            ComputeBuffer<int> resultBuffer = new ComputeBuffer<int>(context,
                ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new int[4]);
            kernel.SetMemoryArgument(0, row1Buffer); // set the integer array
            kernel.SetMemoryArgument(1, row2Buffer); // set the integer array
            kernel.SetValueArgument(2, rowSize); // set the array size
            kernel.SetMemoryArgument(3, resultBuffer); // set the integer array
            // execute kernel
            queue.ExecuteTask(kernel, null);
            // wait for completion
            queue.Finish();
            GCHandle arrCHandle = GCHandle.Alloc(r3, GCHandleType.Pinned);
            queue.Read<int>(resultBuffer, true, 0, r3.Length, arrCHandle.AddrOfPinnedObject(), null);
            Console.WriteLine("display result from gpu buffer:");
            for (int i = 0; i<r3.Length;i++)
                Console.WriteLine(r3[i]);
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
