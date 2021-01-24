    public class test : MonoBehaviour {
        GridLayoutGroup glg;
        
        void Start () {        
            glg = gameObject.GetComponent<GridLayoutGroup>();
            Debug.Log(glg);
            glg.constraint = GridLayoutGroup.Constraint.FixedRowCount;  //**
            glg.constraintCount = 1;                                    //**
        }
    }
        
