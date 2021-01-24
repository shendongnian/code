    /// <summary>
    /// update the flags set for ContractStates and remove a  given state flag
    /// </summary>
    /// <param name="states">the enum to test</param>
    /// <param name="InState">the state to test for</param>
    /// <returns>True if flag is set</returns>
    public static bool IsSet(this ContractStates item, ContractStates InState)
    {
       return (item & InState) != 0;
    }
