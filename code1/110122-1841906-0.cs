    // Form in which the DataGridView, its underlying DataTable and hence the enumeration are:
    public partial class MainMenu : Form {
	(...)
        DataTable dt_expTable;
	//Enum that should have all the info on its own... but does not:
	public enum e_columns {
            [TypeAttribute(typeof(int))]
            Experiments = 0,
            [TypeAttribute(typeof(decimal))]
            Probability,
            [DescriptionAttribute("Samples / Exp.")]
            [TypeAttribute(typeof(int))]
            SamplesXExperiment,
            [DescriptionAttribute("Instances / Sample")]
            [TypeAttribute(typeof(int))]
            InstancesXSample,
            [DescriptionAttribute("Instances / Exp.")]
            [TypeAttribute(typeof(int))]
            [Autocalculated()]
            InstancesXExp,
            [DescriptionAttribute("Total Instances")]
            [TypeAttribute(typeof(long))]
            [Autocalculated()]
            Total_Instances
        };
	
	//These are the two strings
	string instancesXExpString = "[" + DescriptionAttribute.obtain(e_columns.SamplesXExperiment) + "] * [" + DescriptionAttribute.obtain(e_columns.InstancesXMuestra) + "]";
        string totalInstancesString = "[" + DescriptionAttribute.obtain(e_columns.InstancesXExp) + "] * [" + DescriptionAttribute.obtain(e_columns.Experiments) + "]";
	public MainMenu() {
        	InitializeComponent();
		(...)        
        }
	private void MainMenu_Load(object sender, EventArgs e) {
		(...)
		// This is the neat foreach I refered to:
		foreach (e_columns en in Enum.GetValues(typeof(e_columnas))) {
                	addColumnDT(en);
        	}
	}
	private void addColumnDT(Enum en) {
		//*This is a custom static method for a custom attrib. that simply retrieves the description string or
		//the standard .ToString() if there is no such attribute.*/
            	string s_columnName = DescriptionAttribute.obtain(en);
            	bool b_typeExists;
            	string s_calculusString;
            	Type TypeAttribute = TypeAttribute.obtain(en, out b_typeExists);
            	if (!b_typeExists) throw (new ArgumentNullException("Type has not been defined for one of the columns."));
            	if (isCalculatedColumn(DescriptionAttribute.obtain(en))) {
                	s_calculusString = calcString(en);
                	dt_expTable.Columns.Add(s_columnName, TypeAttribute, s_calculusString);
            	} else {
                	dt_expTable.Columns.Add(s_columnName, TypeAttribute);
            	}
        }
	private string calcString(Enum en) {
            if (en.ToString() == e_columns.InstancessXExp.ToString()) {
                return instancesXExpString;
            } else if (en.ToString() == e_columns.Total_Samples.ToString()) {
                return totalInstancesString;
            } else throw (new ArgumentException("There is a column with the autocalculated attribute whose calculus string has not been considered."));
        }
	(...)
    }
