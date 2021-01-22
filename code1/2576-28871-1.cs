      public string GetLocalString(idType objectId, string fieldName)
      {
        switch (_currentLanguage)
        {
          case Language.English:
            // db access code to retrieve your string, may need to include the table
            // the object is in (e.g. "Products" "Orders" etc.)
            db.GetValue(objectId, fieldName, "en-us");
            break;
        }
      }
