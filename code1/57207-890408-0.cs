    [XmlArray("Characters")]
    [XmlArrayItem("Character", Type=typeof(Character))]
    public Character[] _ Characters
    {
        get
        {
            //Make an array of Characters to return 
            return Characters.ToArray();
        }
    
        set
        {
            Characters.Clear();
            for( int i = 0; i < value.Length; i++ )
                Characters.Add( value[i] );
        }
    }
