    public static void GobbleGobble(this string value, string extra)
    {                                            |              |
        ...                                      |              |
    }                                            |              |
                                                 |              |
    +--------------------------------------------+              |
    |                                                           |
    v                                                           |
    s.GobbleGobble("extra goes here");                          |
                            ^                                   |
                            |                                   |
                            +-----------------------------------+
