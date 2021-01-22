        [Category("Behavior - ObjectListView"),
         Description("Draw this column cell's word wrapped"),
         DefaultValue(false)]
        public bool WordWrap {
            get { return wordWrap; }
            set { 
                wordWrap = value;
                if (wordWrap) {
                    this.Renderer = new BaseRenderer();
                    ((BaseRenderer)this.Renderer).CanWrap = true;
                    ((BaseRenderer)this.Renderer).UseGdiTextRendering = false;
                } else {
                    this.Renderer = null;
                }
            }
        }
        private bool wordWrap;
