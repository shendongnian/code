        public static bool IsRunning(this Process process)
        {
            try  {Process.GetProcessById(process.Id);}
            catch (InvalidOperationException) { return false; }
            catch (ArgumentException){return false;}
            return true;
        }
