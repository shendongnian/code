    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Web.UI;
    
    namespace Controls
    {
    
    	public class UpdatePanelCss : UpdatePanel
    	{
    		private string _cssClass;
    		private HtmlTextWriterTag _tag = HtmlTextWriterTag.Div;
    
    		public HtmlAttributes HtmlAttributes = new HtmlAttributes();
    		[DefaultValue("")]
    		[Description("Applies a CSS style to the panel.")]
    		public string CssClass {
    			get { return _cssClass ?? String.Empty; }
    			set { _cssClass = value; }
    		}
    
    		// Hide the base class's RenderMode property since we don't use it
    		[Browsable(false)]
    		[EditorBrowsable(EditorBrowsableState.Never)]
    		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    		public new UpdatePanelRenderMode RenderMode {
    			get { return base.RenderMode; }
    			set { base.RenderMode = value; }
    		}
    
    		[DefaultValue(HtmlTextWriterTag.Div)]
    		[Description("The tag to render for the panel.")]
    		public HtmlTextWriterTag Tag {
    			get { return _tag; }
    			set { _tag = value; }
    		}
    
    		protected override void RenderChildren(HtmlTextWriter writer)
    		{
    			if (IsInPartialRendering) {
    				// If the UpdatePanel is rendering in "partial" mode that means
    				// it's the top-level UpdatePanel in this part of the page, so
    				// it doesn't render its outer tag. We just delegate to the base
    				// class to do all the work.
    				base.RenderChildren(writer);
    			} else {
    				// If we're rendering in normal HTML mode we do all the new custom
    				// rendering. We then go render our children, which is what the
    				// normal control's behavior is.
    				writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
    				if (CssClass.Length > 0) {
    					writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
    				}
    				if (HtmlAttributes.Count > 0) {
    					foreach (HtmlAttribute ha in HtmlAttributes) {
    						writer.AddAttribute(ha.AttrName, ha.AttrVal);
    					}
    				}
    				writer.RenderBeginTag(Tag);
    				foreach (Control child in Controls) {
    					child.RenderControl(writer);
    				}
    				writer.RenderEndTag();
    			}
    		}
    
    	}
    
    	public class HtmlAttribute
    	{
    		private string PAttrName;
    
    		private string PAttrVal;
    		public HtmlAttribute(string AttrName, string AttrVal)
    		{
    			PAttrName = AttrName;
    			PAttrVal = AttrVal;
    		}
    
    		public string AttrName {
    			get { return PAttrName; }
    			set { PAttrName = value; }
    		}
    
    		public string AttrVal {
    			get { return PAttrVal; }
    			set { PAttrVal = value; }
    		}
    
    	}
    
    
    	public class HtmlAttributes : CollectionBase
    	{
    
    		public int Count {
    			get { return List.Count; }
    		}
    
    		public HtmlAttribute this[int index] {
    			get { return (HtmlAttribute)List[index]; }
    			set { List[index] = value; }
    		}
    
    		public int Add(HtmlAttribute item)
    		{
    			return List.Add(item);
    		}
    
    		public void Remove(int index)
    		{
    			if (index < List.Count && List[index] != null) {
    				List.RemoveAt(index);
    			} else {
    				throw new Exception(string.Concat("Index(", index.ToString(), ") is not valid. List only has ", List.Count.ToString(), " items."));
    			}
    		}
    
    		public void Remove(ref HtmlAttribute hAttribute)
    		{
    			if (List.Count > 0 && List.IndexOf(hAttribute) >= 0) {
    				List.Remove(hAttribute);
    			} else {
    				throw new Exception("Object does not exist in collection.");
    			}
    		}
    
    	}
    
    
    }
