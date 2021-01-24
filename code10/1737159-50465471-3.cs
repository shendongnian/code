    getBaseDataObject().scan(
      state,
      new ShowText.IScanner()
      {
        @Override
        public void scanChar(
          char textChar,
          Rectangle2D textCharBox,
          double alpha
          )
        {
          textChars.add(
            new TextChar(
              textChar,
              textCharBox,
              alpha,
              style,
              false
              )
            );
        }
      }
      );
