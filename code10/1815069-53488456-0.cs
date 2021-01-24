    private Gameobject[] copies;
    private int dir; 
    public void MoveClones()
    {
        for (int i = 0; i < copies.Length; i++)
        {
            copies[i].SendMessage("MoveDir", dir);
        }
    }
