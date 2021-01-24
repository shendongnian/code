    class NPCFactory
    {
        public GameObject CreateNPC(NPCType npcType)
        {
            GameObject obj = new GameObject();
            obj.AddComponent<StateController>();
            switch(npcType)
            {
               case NPCType.Villager:
                    obj.AddComponent<Villager>();
                    break;
               //case ....
            }
            return obj;
        }
    }
