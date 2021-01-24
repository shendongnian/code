    [CustomEditor(typeof(ClasseTest))]
    public class TestCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            ClasseTest script = (ClasseTest)target;
    
            int numMissoes = EditorGUILayout.IntField("Numero de Missoes", numMissoes);
    
            EditorGUILayout.LabelField("Editante");
            var serializedObject = new SerializedObject(target);
            var property = serializedObject.FindProperty("MissoesJogasso");
            serializedObject.Update();
            EditorGUILayout.PropertyField(property, true);
            serializedObject.ApplyModifiedProperties();
    		
    		// numMissoes being greater than the current count means we need to extend the list.
    		if(numMissoes > script.MissoesJogasso.Count)
    		{
    			for (int i = 0; i < numMissoes; i++)
    			{
    				var missoes = script.MissoesJogasso[i];
    			
    				switch(missoes.TiposMissoes)
    				{
    					case ClasseTest.TiposDeMissoes.TipoMatarGente:
    						missoes.TiposMissoes = (ClasseTest.TiposDeMissoes)EditorGUILayout.EnumPopup("Matar Gentes", missoes.TiposMissoes);
    						break;
    						
    					case ClasseTest.TiposDeMissoes.TipoPegarItem:
    						missoes.TiposMissoes = (ClasseTest.TiposDeMissoes)EditorGUILayout.EnumPopup("Pegar Item", missoes.TiposMissoes);
    						break;
    				}
    			}
    		}
    		else
    		{
    			// We need to decrease the list by the difference (the number of elements to remove)
    			int difference = script.MissoesJogasso.Count - numMissoes;
    			// Calculate the starting index which is given by: total elements - (number of elements to remove + 1)
    			// The plus one accounting for the Count property starting at zero.
    			script.MissoesJogass.RemoveRange(script.MissoesJogass.Count - (difference + 1), difference);
    		}
        }
    }
