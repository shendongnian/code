      class KeyValueData
      {
          public KeyValueData(string Text)
          {
              text = Text;
              itemData = 0;
          }
    
          public KeyValueData(string Text, int ItemData)
          {
              text = Text;
              itemData = ItemData;
          }
    
          public int ItemData
          {
              get
              {
                  return itemData;
              }
              set
              {
                  itemData = value;
              }
          }
    
          public override string ToString()
          {
              return text;
          }
    
          protected string text;
          protected int itemData;
      }
