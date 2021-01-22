            string input = @"Apple1231|C:\asfae\drqw\qwer|2342|1.txt";
            int firstPipeIndex = input.IndexOf("|");
            string suffix = string.Empty;
            string prefix = string.Empty;
            string output = string.Empty;
            if (firstPipeIndex != -1)
            {
                //keep the first pipe and anything before in prefix
                prefix = input.Substring(0, firstPipeIndex + 1);
                //all pipes in the rest of it should be slashes
                suffix = input.Substring(firstPipeIndex + 1).Replace('|', '\\');
                output = prefix + suffix;
            }
            if (!string.IsNullOrEmpty(suffix))
            {
                Console.WriteLine(input);
                Console.WriteLine(output);
            }
