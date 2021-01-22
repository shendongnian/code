    public static int[] notAllowedIDs = new int[] { 23, 24, 25, 26, 27, 29, 31 };
    public static bool isStaffIDValid(int staffID)
    {
        return !((IList<int>)notAllowedIDs).Contains(staffID);
    }
