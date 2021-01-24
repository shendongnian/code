        protected override void OnIncludeCell(IncludeCellArgs e)
         {
         // hiding lunch break
           if (e.Start.Hour == 13)
          {
              e.Visible = false;
          }
         }
