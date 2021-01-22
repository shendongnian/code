        generic<typename T>
        ref class CustomCodeDomSerializer : CodeDomSerializer
        {
        public: virtual Object ^Deserialize(IDesignerSerializationManager ^manager, Object ^codeObject) override
           {
              // This is how we associate the component with the serializer.
              CodeDomSerializer ^baseClassSerializer = (CodeDomSerializer^)manager->
                 GetSerializer(T::typeid->BaseType, CodeDomSerializer::typeid);
        
               //This is the simplest case, in which the class just calls the base class
               //   to do the work. 
              return baseClassSerializer->Deserialize(manager, codeObject);
           }
        
           public: virtual Object ^Serialize(IDesignerSerializationManager ^manager, Object ^value) override
           {
               //Associate the component with the serializer in the same manner as with
               //   Deserialize 
              CodeDomSerializer ^baseClassSerializer = (CodeDomSerializer^)manager->
                 GetSerializer(T::typeid->BaseType, CodeDomSerializer::typeid);
        
              Object ^codeObject = baseClassSerializer->Serialize(manager, value);
        
               //Anything could be in the codeObject.  This sample operates on a
               //   CodeStatementCollection. 
              if (dynamic_cast<CodeStatementCollection^>(codeObject))
              {
                 CodeStatementCollection ^statements = (CodeStatementCollection^)codeObject;
        
                 // The code statement collection is valid, so add a comment.
                 String ^commentText = "This comment was added to this Object by a custom serializer.";
                 CodeCommentStatement ^comment = gcnew CodeCommentStatement(commentText);
                 statements->Insert(0, comment);
              }
              return codeObject;
           }
    
    };
    
    
    
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///   <summary>   
    ///   This Usercontrol is a simple label coupled with a numericupdown.  The class following
    ///   it will wrap this item in toolstrip container so that it can be part of a contextmenu
    ///   </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [DesignerSerializer(CustomCodeDomSerializer<LabeledNumericUpDown^>::typeid, CodeDomSerializer::typeid)]
    public ref class LabeledNumericUpDown : UserControl
    {
       public: event EventHandler ^NumericUpDownValueChanged;
    
       public: [Category("Custom Information"), Description(L"Text to display"), 
                DefaultValue(L"Default Text"), Browsable(true), Localizable(true), NotifyParentProperty(true)]
       property String ^DisplayText
       {
          String ^get()
          {
             return this->label->Text;
          }
          void set(String ^val)
          {
             this->label->Text = val;
             if(this->DesignMode || 
                LicenseManager::UsageMode == LicenseUsageMode::Designtime) 
                this->Invalidate();
             
          }
       }
      //designer stuff not important
    }
    
    
    
    
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability::All),
     ToolboxBitmap(::NumericUpDown::typeid)]
    public ref class NumericUpDownToolStripItem : ToolStripControlHost
    {
       //replace this type
       private: LabeledNumericUpDown ^_Control;
       
       public: [Category("Object Host"), Description(L"Hosted usercontrol object"), 
        DisplayName("UserControl Object"), Browsable(true), NotifyParentProperty(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility::Content)]
        //replace this properties type
       property LabeledNumericUpDown ^UserControlObject
       {
         //replace this properties return type
         LabeledNumericUpDown ^get() { return this->_Control; }
       } 
    
       public: NumericUpDownToolStripItem(void) : 
          System::Windows::Forms::ToolStripControlHost(gcnew FlowLayoutPanel())
    	{ 
          //replace this constructor type
          _Control = gcnew LabeledNumericUpDown();
          
          //don't touch this
          FlowLayoutPanel ^thePanel = (FlowLayoutPanel ^)this->Control;
          thePanel->BackColor = Color::Transparent;
          thePanel->Controls->Add(_Control);
       }   
    };
