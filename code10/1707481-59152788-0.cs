public class User
{
    public string name;
    public string[] items;
    public string email;
    public string ToString()
    {
        return name + ", " + email + ", " + items.ToString();
    }
}
Read data from Firebase Realtime Database:
FirebaseDatabase.DefaultInstance.RootReference.Child("users").Child("FIREBASE_UID_HERE").GetValueAsync().ContinueWith(t =>
{
    if (t.IsCanceled)
    {
        Debug.Log("FirebaseDatabaseError: IsCanceled: " + t.Exception);
        return;
    }
    if(t.IsFaulted)
    {
        Debug.Log("FirebaseDatabaseError: IsFaulted:" + t.Exception);
        return;
    }
    DataSnapshot snapshot = t.Result;
    User user = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());
    Debug.Log(user.ToString());
});
