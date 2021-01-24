        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            Console.WriteLine(e.Conflict.Type);
            Console.WriteLine(e.Error);
        }
