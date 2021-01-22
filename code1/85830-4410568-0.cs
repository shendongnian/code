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
          String ^get();
          void set(String ^val);
       }
    
       public: [Category("Custom Information"), Description(L"NumericUpDown Value"), 
                DefaultValue(1), Browsable(true), Localizable(true), NotifyParentProperty(true)]
       property Decimal UpDownValue
       {
          Decimal get();
          void set(Decimal val);
       }
    
       public: [Category("Custom Information"), Description(L"NumericUpDown Maximum"), 
                DefaultValue(100), Browsable(true), Localizable(true), NotifyParentProperty(true)]
       property Decimal UpDownMaximum
       {
          Decimal get();
          void set(Decimal val);
       }
    
       public: [Category("Custom Information"), Description(L"NumericUpDown Minimum"), 
                DefaultValue(0), Browsable(true), Localizable(true), NotifyParentProperty(true)]
       property Decimal UpDownMinimum
       {
          Decimal get();
          void set(Decimal val);
       }
    
       private: bool SupressEvents;
       public: Void UpDownValueSet_NoEvent(int Val);
       private: Void numericUpDown_ValueChanged(Object ^sender, EventArgs ^e);
       public: LabeledNumericUpDown(void);
       private: System::Windows::Forms::NumericUpDown^  numericUpDown;
       private: System::Windows::Forms::Label^  label;
       private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel1;
       private: System::ComponentModel::Container ^components;
       #pragma region Windows Form Designer generated code
       void InitializeComponent(void);
    };
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   CustomCodeDomSerializer
    /// This is a specialized usercontrol designed to incapsulate another usercontrol (in this case a  
    /// NumericUpDownToolStripItem.  In order to use this class, you must copy this entire class and 
    /// create a new object.  (You can do this right underneath your usercontrol in the same file 
    /// if you wish.  You must specifiy the type of your object every place its mentioned.
    ///   
    /// To Note:  The toolbox bitmap is what the icon will look like.  You can specify any old control.
    /// It is possible to use a custom icon, but I can't figure out how.
    ///</summary>
    /// 
    /// <value> The tool strip control host. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
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
