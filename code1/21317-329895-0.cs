    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public class EmptyCapableRepeater : Repeater
    {
        public ITemplate EmptyDataTemplate { get; set; }
    
        protected override void OnDataBinding ( EventArgs e )
        {
            base.OnDataBinding( e );
    
            if ( this.Items.Count == 0 )
            {
                EmptyDataTemplate.InstantiateIn( this );
            }
        }
    }
