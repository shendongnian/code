        public unsafe void PointerTest()
        {
            int x = 100; // Create a variable named x
            
            int *ptr = &x; // Now, this is the 'wow' line. Here, we store the address of variable named x into the pointer named ptr
            textBox1.Text = ((int)ptr).ToString(); ; // Displays the memory address stored in pointer named ptr
            textBox2.Text = (*ptr).ToString(); // Displays the value of the variable named x via the pointer named ptr.
            
        }
