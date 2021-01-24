    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using SimpleJSON;
    
    public class CreateSearchResult : MonoBehaviour
    {
    	public string queryURL = "http://http://localhost/dmcs/getdata.php?keyword=";
    	public string imgURL = "http://http://localhost/dmcs/people/";
    
    	public void PopulateList()
    	{
    		StartCoroutine(GetResult());
    	}
    
    	IEnumerator GetResult()
    	{
    		string jsonData = "";
    
    		WWW result_get = new WWW(queryURL + searchInput.text);
    		yield return result_get;
    
    		if (result_get.error != null)
    		{
    			print("There was an error : " + result_get.error);
    		}
    		else
    		{
    			JSONNode jsonNode = JSON.Parse(jsonData);
    			int resultQty = int.Parse(jsonNode["content"]);
    
    			for (int i = 0; i < resultQty; i++)
    			{
    				string name = jsonNode["keyword"][i]["name"];
    				string building = jsonNode["keyword"][i]["building"];
    				// And so on... 
    			}
    		}
    	}
