    Dictionary<string, bool> Monsters = new Dictionary<string, bool>();
    private void OnTriggerExit2D(Collider2D col)
    {
        for (var i = 0; i < 9; i++)
        {
            string monsterID = "monster" + i;
            Monsters[monsterID] = col.name != monsterID;
        }
    }
