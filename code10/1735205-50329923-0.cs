    namespace example
    {
        class test
        {
            [DllImport("mytest.dll", CallingConvention = CallingConvention.Cdecl)]
            unsafe public static extern void* add_node(void *head, int data);
            [DllImport("mytest.dll", CallingConvention = CallingConvention.Cdecl)]
            unsafe public static extern void print_DB(void *head);
            unsafe static void Main(string[] args)
            {
                /*initilialization*/
                head = add_node(head, a) 
                head = add_node(head, b) 
                head = add_node(head, c) 
                printDB(head);
            }
        }
    }
