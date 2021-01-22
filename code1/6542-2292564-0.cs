    public enum SuperTasks : int
        {
            Sleep = 5,
            Walk = 7,
            Run = 9
        }
        private void btnTestEnumWithReflection_Click(object sender, EventArgs e)
        {
            SuperTasks task = SuperTasks.Walk;
            Type underlyingType = Enum.GetUnderlyingType(task.GetType());
            object value = Convert.ChangeType(task, underlyingType); // x will be int
        }    
