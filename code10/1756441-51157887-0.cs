    using UnityEngine;
    using System.Collections;
    using MySql.Data.MySqlClient;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class MySqlTestScript : MonoBehaviour
    {
    
    private static MySqlTestScript _instnace;
    public static MySqlTestScript sharedInstance()
    {
        return _instnace;
    }
    
    
    string row = "";
    
    public string host = "*****";
    public string database = "*******";
    public string usrename= "*******";
    public string password = "******";
    
    public List<AppUser> users = new List<AppUser>();
    
    void Awake()
    {
        _instnace = this;
    }
    
    
    // Use this for initialization
    public void Start()
    {
    
        GetDataFromDatabase();
    }
    
    public string GetDataFromDatabase()
    {
      string myConnectionString = "Server=" + host + ";Database=" + database + ";Uid=" + usrename + ";Pwd=" + password + ";";
      MySqlConnection connection = new MySqlConnection(myConnectionString);
      MySqlCommand command = connection.CreateCommand();
      command.CommandText = "SELECT * FROM users";
      MySqlDataReader Reader;
    
      try
      {
        connection.Open();
        Reader = command.ExecuteReader();
        while (Reader.Read())
        {
          users.Add(new AppUser() { 
            username = Reader.GetString("UserName").Trim(),
            rfid = Reader.GetString("longNumbers ").Trim()
          });
        }
      }
      catch (Exception x)
      {
        Debug.Log(x.Message);
        return x.Message;
      }
      connection.Close();
      return row;
    }
    }
